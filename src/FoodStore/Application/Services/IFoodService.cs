using ErrorOr;
using FoodStore.Application.Foods.Commands;
using FoodStore.Application.Foods.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStore.Application.Services;

public interface IFoodService
{
    Task<ErrorOr<Unit>> AddFoodAsync(CreateFood.CreateFoodCommand food);
    Task<ErrorOr<IList<GetAllFoods.Response>>> GetAllFoodsWithCategoriesAsync(CancellationToken cancellationToken);
    Task<ErrorOr<FindFood.Response>> FindFoodAsync(int foodId, CancellationToken cancellationToken);
}
