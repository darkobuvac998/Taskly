using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.Data
{
    public partial class TasklyDbContext : DbContext
    {
        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Models.Task> Tasks { get; set; }
        public virtual DbSet<TaskChecklist> TaskChecklists { get; set; }

        public TasklyDbContext(DbContextOptions<TasklyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Scaffolding:ConnectionString", "Data Source=(local);Initial Catalog=TasklyAPI.Database;Integrated Security=true");

            modelBuilder.Entity<Board>(entity =>
            {
                entity.HasKey(e => e.BoardId);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.HasKey(e => e.PriorityId);

                entity.Property(e => e.Color).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.Property(e => e.Color).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Models.Task>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.Property(e => e.AttachmentLink).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Note).IsUnicode(false);

                entity.HasOne(d => d.Board)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.BoardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Board");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.PriorityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Priority");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Status");
            });

            modelBuilder.Entity<TaskChecklist>(entity =>
            {
                entity.HasKey(e => e.TaskChecklistId);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskChecklists)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskChecklist_Task");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
