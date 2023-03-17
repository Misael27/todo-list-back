using TodoList.Core.Entities;
using TodoList.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Web
{
    public static class Seed
    {
        public static int SeedDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                CreateTaskState(context);
                CreateTaskCategory(context);
            }
            return 1;
        }
        private static int CreateTaskState(DataContext? dataContext)
        {
            InsertTaskState(dataContext, "Active");
            InsertTaskState(dataContext, "Completed");
            return 1;
        }

        private static int InsertTaskState(DataContext? dataContext, string stateName)
        {
            var taskState = dataContext?.TaskState.FirstOrDefault(x => x.Name == stateName);
            if (taskState == null)
            {
                dataContext?.TaskState.Add(new TaskState()
                {
                    Name = stateName
                });
                dataContext?.SaveChanges();
            }
            return 1;
        }

        private static int CreateTaskCategory(DataContext? dataContext)
        {
            InsertTaskCategory(dataContext, "Health", "#1C89BF");
            InsertTaskCategory(dataContext, "Work", "#512da8");
            InsertTaskCategory(dataContext, "Family", "#F57C00");
            InsertTaskCategory(dataContext, "Other ", "#00b96b");
            return 1;
        }

        private static int InsertTaskCategory(DataContext? dataContext, string categoryName, string color)
        {
            var taskCategory = dataContext?.TaskCategory.FirstOrDefault(x => x.Name == categoryName);
            if (taskCategory == null)
            {
                dataContext?.TaskCategory.Add(new TaskCategory()
                {
                    Name = categoryName,
                    Color = color
                });
                dataContext?.SaveChanges();
            }
            return 1;
        }

    }
}
