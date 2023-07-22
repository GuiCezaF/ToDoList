using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;

namespace ToDoList.Infra.Data.Maps
{
    public class ToDoMap : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
        }
    }
}