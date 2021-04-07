using Fenicia.Application.Common.Interfaces.UseCases.Addresses;
using Fenicia.Application.Common.Interfaces.UseCases.Categories;
using Fenicia.Application.Common.Interfaces.UseCases.Countries;
using Fenicia.Application.Common.Interfaces.UseCases.Customer;
using Fenicia.Application.Common.Interfaces.UseCases.Employees;
using Fenicia.Application.Common.Interfaces.UseCases.OrderItems;
using Fenicia.Application.Common.Interfaces.UseCases.Orders;
using Fenicia.Application.Common.Interfaces.UseCases.Products;
using Fenicia.Application.Common.Interfaces.UseCases.Users;
using Fenicia.Application.UseCases.Addresses.Add;
using Fenicia.Application.UseCases.Addresses.Delete;
using Fenicia.Application.UseCases.Addresses.Get.GetAll;
using Fenicia.Application.UseCases.Addresses.Get.GetById;
using Fenicia.Application.UseCases.Addresses.Update;
using Fenicia.Application.UseCases.Categories.Add;
using Fenicia.Application.UseCases.Categories.Delete;
using Fenicia.Application.UseCases.Categories.Get.GetAll;
using Fenicia.Application.UseCases.Categories.Get.GetById;
using Fenicia.Application.UseCases.Categories.Update;
using Fenicia.Application.UseCases.Countries.Add;
using Fenicia.Application.UseCases.Countries.Delete;
using Fenicia.Application.UseCases.Countries.Get.GetAll;
using Fenicia.Application.UseCases.Countries.Get.GetById;
using Fenicia.Application.UseCases.Countries.Update;
using Fenicia.Application.UseCases.Customers.Add;
using Fenicia.Application.UseCases.Customers.Delete;
using Fenicia.Application.UseCases.Customers.Get.GetAll;
using Fenicia.Application.UseCases.Customers.Get.GetById;
using Fenicia.Application.UseCases.Customers.Update;
using Fenicia.Application.UseCases.Employees.Delete;
using Fenicia.Application.UseCases.Employees.Get.GetAll;
using Fenicia.Application.UseCases.Employees.Get.GetEmployeeById;
using Fenicia.Application.UseCases.Employees.Update;
using Fenicia.Application.UseCases.OrderItems.Get.GetAll;
using Fenicia.Application.UseCases.Orders.Add;
using Fenicia.Application.UseCases.Orders.Delete;
using Fenicia.Application.UseCases.Orders.Get.GetAll;
using Fenicia.Application.UseCases.Orders.Get.GetById;
using Fenicia.Application.UseCases.Orders.Update;
using Fenicia.Application.UseCases.Products.Add;
using Fenicia.Application.UseCases.Products.Delete;
using Fenicia.Application.UseCases.Products.Get.GetById;
using Fenicia.Application.UseCases.Products.GetProduct;
using Fenicia.Application.UseCases.Products.Update;
using Fenicia.Application.UseCases.RegisterEmployee;
using Fenicia.Application.UseCases.Users.Delete;
using Fenicia.Application.UseCases.Users.Get;
using Fenicia.Application.UseCases.Users.Login;
using Fenicia.Application.UseCases.Users.Register;
using Fenicia.Application.UseCases.Users.UpdateUser;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fenicia.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Employees
            services.AddScoped<IRegisterEmployeeInteractor, RegisterEmployeeInteractor>();
            services.AddScoped<IGetAllEmployeesInteractor, GetAllEmployeesInteractor>();
            services.AddScoped<IGetEmployeeByIdInteractor, GetEmployeeByIdInteractor>();
            services.AddScoped<IUpdateEmployeeInteractor, UpdateEmployeeInteractor>();
            services.AddScoped<IDeleteEmployeeInteractor, DeleteEmployeeInteractor>();
           
            //Users
            services.AddScoped<ILoginUserInteractor, LoginUserInteractor>();
            services.AddScoped<IRegisterUserInteractor, RegisterUserInteractor>();
            services.AddScoped<IGetAllUsersInteractor, GetAllUsersInteractor>();
            services.AddScoped<IUpdateUserInteractor, UpdateUserInteractor>();
            services.AddScoped<IDeleteUserInteractor, DeleteUserInteractor>();

            //Categories
            services.AddScoped<IAddCategoryInteractor, AddCategoryInteractor>();
            services.AddScoped<IGetAllCategoryInteractor, GetAllCategoryInteractor>();
            services.AddScoped<IGetCategoryByIdInteractor, GetCategoryByIdInteractor>();
            services.AddScoped<IUpdateCategoryInteractor, UpdateCategoryInteractor>();
            services.AddScoped<IDeleteCategoryInteractor, DeleteCategoryInteractor>();

            //Products
            services.AddScoped<IAddProductInteractor, AddProductInteractor>();
            services.AddScoped<IGetAllProductInteractor, GetAllProductsInteractor>();
            services.AddScoped<IGetProductByIdInteractor, GetProductByIdInteractor>();
            services.AddScoped<IUpdateProductInteractor, UpdateProductInteractor>();
            services.AddScoped<IDeleteProductInteractor, DeleteProductInteractor>();

            //Customers
            services.AddScoped<IAddCustomerInteractor, AddCustomerInteractor>();
            services.AddScoped<IGetAllCustomerInteractor, GetAllCustomerInteractor>();
            services.AddScoped<IGetCustomerByIdInteractor, GetCustomerByIdInteractor>();
            services.AddScoped<IUpdateCustomerInteractor, UpdateCustomerInteractor>();
            services.AddScoped<IDeleteCustomerInteractor, DeleteCustomerInteractor>();

            //Countries
            services.AddScoped<IGetAllCountryInteractor, GetAllCountryInteractor>();
            services.AddScoped<IGetCountryByIdInteractor, GetCountryByIdInteractor>();
            services.AddScoped<IAddCountryInteractor, AddCountryInteractor>();
            services.AddScoped<IUpdateCountryInteractor, UpdateCountryInteractor>();
            services.AddScoped<IDeleteCountryInteractor, DeleteCountryInteractor>();

            //Addresses
            services.AddScoped<IGetAllAddressInteractor, GetAllAddressInteractor>();
            services.AddScoped<IGetAddressByIdInteractor, GetAddressByIdInteractor>();
            services.AddScoped<IAddAddressInteractor, AddAddressInteractor>();
            services.AddScoped<IUpdateAddressInteractor, UpdateAddressInteractor>();
            services.AddScoped<IDeleteAddressInteractor, DeleteAddressInteractor>();

            //Orders
            services.AddScoped<IGetAllOrderInteractor, GetAllOrderInteractor>();
            services.AddScoped<IGetOrderByIdInteractor, GetOrderByIdInteractor>();
            services.AddScoped<IAddOrderInteractor, AddOrderInteractor>();
            services.AddScoped<IUpdateOrderInteractor, UpdateOrderInteractor>();
            services.AddScoped<IDeleteOrderInteractor, DeleteOrderInteractor>();

            //OrderItems
            services.AddScoped<IGetAllOrderItemInteractor, GetAllOrderItemInteractor>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
