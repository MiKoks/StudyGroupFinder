using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BLL.App;
using BLL.App.Mappers;
using BLL.App.Services;
using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using DAL.Base;
using DAL.Contracts.Base;
using DAL.EF.App;
using DAL.EF.App.Repositories;
using Domain.Contracts.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Moq;
using Public.DTO.v1;
using WebApp.ApiControllers;
using Xunit.Abstractions;
using AutomapperConfig = DAL.EF.App.AutomapperConfig;

namespace Tests.Unit;

public class UnitTestBaseService
{
    
    private readonly Mock<IBaseRepository<DalCourseCategory>> _baseRepositoryMock;
    private readonly BaseEntityService<BllCourseCategoryData, DalCourseCategory,
            IBaseRepository<DalCourseCategory>>
        _baseEntityService;


    public UnitTestBaseService()
    {

        _baseRepositoryMock = new Mock<IBaseRepository<DalCourseCategory>>();
        _baseEntityService =
            new BaseEntityService<BllCourseCategoryData, DalCourseCategory, IBaseRepository<DalCourseCategory>>(
                _baseRepositoryMock.Object,
                new BaseMapper<BllCourseCategoryData, DalCourseCategory>(
                    new MapperConfiguration(cfg => cfg
                            .CreateMap<DalCourseCategory, BllCourseCategoryData>().ReverseMap()
                        )
                        .CreateMapper()));
    }

    [Fact]
    public async Task BaseService__All_Async_Should_Have_3_Elements()
    {
        var expectedDatas = new List<DalCourseCategory>()
        {
            new DalCourseCategory()
            {
                CourseName = "Füüsika",
                CourseCode = "ICD0001",
                Id = Guid.NewGuid(),
            },
            
            new DalCourseCategory()
            {
                CourseName = "Füüsika II",
                CourseCode = "ICD0017",
                Id = Guid.NewGuid(),
            },
            
            new DalCourseCategory()
            {
                CourseName = "Hajusussüsteemid",
                CourseCode = "ICD0020",
                Id = Guid.NewGuid(),
            },
        };
        
        // Arrange
        _baseRepositoryMock.Setup(r => r.AllAsync()).ReturnsAsync(expectedDatas);

        // Act
        var result = (await _baseEntityService.AllAsync()).ToList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());

        foreach (var expectedData in expectedDatas)
        {
            var resultData = result.ToList().FirstOrDefault(x => x.Id == expectedData.Id);
            Assert.NotNull(resultData);
            Assert.Equal(expectedData.CourseName, resultData.CourseName);
        }
    }
    
    
    [Fact]
    public async void BaseService_Find_Async_Item_By_Item_Id()
    {
        var expectedElement = new DalCourseCategory()
        {
            CourseName = "Füüsika",
            CourseCode = "ICD0001",
            Id = Guid.NewGuid(),
        };
        
        var tempDb = new List<DalCourseCategory>()
        {
            new ()
            {
                CourseName = expectedElement.CourseName,
                CourseCode = expectedElement.CourseCode,
                Id = expectedElement.Id
            }
        };

        _baseRepositoryMock.Setup(r =>
                r.FindAsync(It.IsAny<Guid>()))
            .Returns<Guid>((id) =>
            {
                var res = tempDb.FirstOrDefault(x => x.Id == id);
                return Task.FromResult(res);
            });


        var result = (await _baseEntityService.FindAsync(expectedElement.Id));

        // Assert
        Assert.NotNull(result);
        Assert.Single(tempDb.ToList());

        Assert.Equal(expectedElement.CourseName, result.CourseName);
        Assert.Equal(expectedElement.Id, result.Id);
    }
    
    [Fact]
    public void BaseService_Add_Should_Add_Item_To_Memory()
    {
        var tempDb = new List<DalCourseCategory>();
        var expectedElement = new BllCourseCategoryData()
        {
            CourseName = "Füüsika",
            CourseCode = "Icd0001",
            Id = Guid.NewGuid()
        };
        _baseRepositoryMock.Setup(r =>
                r.Add(It.IsAny<DalCourseCategory>()))
            .Returns<DalCourseCategory>((entity) =>
            {
                tempDb.Add(entity);
                return entity;
            });

        var result = _baseEntityService
            .Add(expectedElement);


        // Assert
        Assert.NotNull(result);
        Assert.Single(tempDb.ToList());

        Assert.Equal(expectedElement.CourseCode, result.CourseCode);
        Assert.Equal(expectedElement.Id, result.Id);

        foreach (var item in tempDb)
        {
            var searchableItem = tempDb.FirstOrDefault(x => x.Id == item.Id);
            Assert.NotNull(searchableItem);
            Assert.Equal(expectedElement.CourseCode, item.CourseCode);
        }
    }
    
    [Fact]
    public  void BaseService_Update_Should_Update_Item_In_Memory()
    {
        var expectedElement = new BllCourseCategoryData()
        {
            CourseName = "Füüsika",
            CourseCode = "ICD0001",
            Id = Guid.NewGuid()
        };
        
        var tempDb = new List<DalCourseCategory>()
        {
            new ()
            {
                CourseName = expectedElement.CourseName,
                Id = expectedElement.Id
            }
        };
        var updatedValue = "FooBar";

        _baseRepositoryMock.Setup(r =>
                r.Update(It.IsAny<DalCourseCategory>()))
            .Returns<DalCourseCategory>((entity) =>
            {
                var returnable = tempDb.FirstOrDefault(x => x.Id == entity.Id);
                returnable!.CourseName = entity.CourseName;
                return entity;
            });

        expectedElement.CourseName = updatedValue;
        var result = (_baseEntityService.Update(expectedElement));

        // Assert
        Assert.NotNull(result);

        Assert.Equal(expectedElement.CourseName, result.CourseName);
        Assert.Equal(expectedElement.Id, result.Id);

        foreach (var item in tempDb)
        {
            var searchableItem = tempDb.FirstOrDefault(x => x.Id == item.Id);
            Assert.NotNull(searchableItem);
            Assert.Equal(expectedElement.CourseName, item.CourseName);
        }
    }
    
    [Fact]
    public async void BaseService__Remove_Async_Remove_Item_From_Memory()
    {
        var expectedElement = new BllCourseCategoryData()
        {
            CourseName = "Füüsika",
            CourseCode = "Icd0001",
            Id = Guid.NewGuid()
        };
        var tempDb = new List<DalCourseCategory>()
        {
            new DalCourseCategory
            {
                CourseName = expectedElement.CourseName,
                CourseCode = expectedElement.CourseCode,
                Id = expectedElement.Id
            }
        };

        _baseRepositoryMock.Setup(r =>
                r.RemoveAsync(It.IsAny<Guid>()))
            .Returns<Guid>( (id) =>
            {
                var returnable = tempDb.FirstOrDefault(x => x.Id == id);
                tempDb.Remove(returnable!);
                return  Task.FromResult(returnable);
            });

        var result = (await _baseEntityService.RemoveAsync(expectedElement.Id));

        // Assert
        Assert.NotNull(result);

        Assert.Equal(expectedElement.CourseName, result.CourseName);
        Assert.Equal(expectedElement.Id, result.Id);
    
        Assert.Empty(tempDb.ToList());        
    }

    [Fact]
    public  void BaseService__Remove_Remove_Item_From_Memory()
    {
        
        var expectedElement = new BllCourseCategoryData()
        {
            CourseName = "Füüsika",
            CourseCode = "Icd0001",
            Id = Guid.NewGuid()
        };
        var tempDb = new List<DalCourseCategory>()
        {
            new ()
            {
                CourseName = expectedElement.CourseName,
                CourseCode = expectedElement.CourseCode,
                Id = expectedElement.Id
            }
        };

        _baseRepositoryMock.Setup(r =>
                r.Remove(It.IsAny<DalCourseCategory>()))
            .Returns<DalCourseCategory>( ( entity) =>
            {
                var returnable = tempDb.FirstOrDefault(x => x.Id == entity.Id);
                tempDb.Remove(returnable!);
                return  returnable!;
            });

        var result = ( _baseEntityService.Remove(expectedElement));

        // Assert
        Assert.NotNull(result);

        Assert.Equal(expectedElement.CourseName, result.CourseName);
        Assert.Equal(expectedElement.Id, result.Id);
    
        Assert.Empty(tempDb.ToList()); 
    }
}

    public class BllCourseCategoryData : IDomainEntityId
    {
        
        public string CourseName { get; set; } = default!;
        public string CourseCode { get; set; } = default!;

        public Guid Id { get; set; }
    }

    public class DalCourseCategory : IDomainEntityId<Guid>, IDomainEntityId
    {
        
        public string CourseName { get; set; } = default!;
        public string CourseCode { get; set; } = default!;

        public Guid Id { get; set; }
    }
    
    
