﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudRepoPatternUoF_CQRS.Core.Models;
public class Book
{
    [Key]
    public int Id { get; set; } 

    public string Title { get; set; } 
   
    public string AutherName { get; set; } 

    public string Description { get; set; } 

}
