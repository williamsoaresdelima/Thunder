using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskList.Data.Entities.Enum;
using TaskList.Data.Entities.Enum.Extensions;

namespace TaskList.Data.Entities
{
    [Table("Tasks")]
    public class TaskEntity : BaseEntity
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public StatusTask Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [NotMapped]
        public string StatusDescription => Status.GetDescription();

        public override void EntityMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEntity>(e =>
            {
                e.Property(e => e.CreationDate)
                .IsRequired(true)
                .HasColumnType("TIMESTAMP WITHOUT TIME ZONE");

                e.Property(e => e.StartDate)
                .IsRequired(false)
                .HasColumnType("TIMESTAMP WITHOUT TIME ZONE");

                e.Property(e => e.EndDate)
                .IsRequired(false)
                .HasColumnType("TIMESTAMP WITHOUT TIME ZONE");

                e.Property(e => e.Title)
                .IsRequired(true);

                e.Property(e => e.Description)
                .IsRequired(true);

                e.Property(e => e.Status)
                .IsRequired(true);
            });
        }
        public void Mock(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Title = "Task Test 1";
            Description = "Task Test 1 description";
            Status = StatusTask.Pending;
        }
    }
}
