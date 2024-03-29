﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeSec.Models
{
    public class ApplicationDbContext:DbContext
    {
        //constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
        public DbSet<SickNote> SickNotes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SickNoteStatus> SickNoteStatuses { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<Sequence> Sequences { get; set; }
    }
}
