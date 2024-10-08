﻿using Authentication.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, RoleEF, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) 
        {
        }

        public DbSet<Content> contents { get; set; }
        public DbSet<Tag> tags { get; set; }
        public DbSet<ContentTag> contentTags { get; set; }
        public DbSet<PermissionEF> permissions { get; set; }
        public DbSet<RoleEF> roles { get; set; }
        public DbSet<RolePermissionEF> rolePermissionEFs { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Roles and Permissions Relationship
            modelBuilder.Entity<RolePermissionEF>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<RolePermissionEF>()
               .HasOne(rp => rp.RoleEF)
               .WithMany(r => r.RolePermissions)
               .HasForeignKey(rp => rp.RoleId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RolePermissionEF>()
                .HasOne(rp => rp.PermissionEF)
                .WithMany(p => p.rolePermissions)
                .HasForeignKey(rp => rp.PermissionId);
           

            //user and content
            modelBuilder.Entity<Content>()
                .HasOne(c => c.Author)
                .WithMany(u => u.Content)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            //content and tags
            modelBuilder.Entity<ContentTag>()
                .HasKey(ct => new { ct.ContentID, ct.TagID });

            modelBuilder.Entity<ContentTag>()
                .HasOne(ct => ct.Content)
                .WithMany(c => c.ContentTags)
                .HasForeignKey(ct => ct.TagID);

            modelBuilder.Entity<ContentTag>()
                .HasOne(ct => ct.Tag)
                .WithMany(t => t.ContentTag)
                .HasForeignKey(ct => ct.TagID);

            base.OnModelCreating(modelBuilder);
        }

    }
}
