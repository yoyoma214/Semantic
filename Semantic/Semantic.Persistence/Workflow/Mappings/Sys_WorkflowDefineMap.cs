﻿#region COPYRIGHT MOTOROLA SOLUTIONS
/*******************************************************************************
*                     COPYRIGHT 2014 MOTOROLA SOLUTIONS, INC
*                           ALL RIGHTS RESERVED.
*                     MOTOROLA SOLUTIONS CONFIDENTIAL PROPRIETARY
********************************************************************************
*
*   FILE NAME       : Sys_WorkflowDefineMap.cs
*
*--------------------------------- REVISIONS -----------------------------------
* CR/PR             Core ID   Date        Description
* ---------------   --------  ----------  --------------------------------------
* OA140422183258    amb4114   05/04/2014   Creation
*******************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using CodeHelper.Persistence.Workflow.Models;

namespace CodeHelper.Persistence.Workflow.Mappings
{

    public class Sys_WorkflowDefineMap : EntityTypeConfiguration<Sys_WorkflowDefine>
    {
        public Sys_WorkflowDefineMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            ToTable("Sys_WorkflowDefine");

            Property(t => t.AssembleName).HasMaxLength(500);
            Property(t => t.CreateTime);
            Property(t => t.Description).HasMaxLength(500);
            Property(t => t.Id).IsRequired();
            Property(t => t.Name).HasMaxLength(500);
            Property(t => t.Namespace).HasMaxLength(500);
            Property(t => t.Status);
            Property(t => t.UpdateTime);

            Property(t => t.AssembleName).HasColumnName("AssembleName");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.Namespace).HasColumnName("Namespace");
            Property(t => t.Status).HasColumnName("Status");
            Property(t => t.UpdateTime).HasColumnName("UpdateTime");
        }
    }
}