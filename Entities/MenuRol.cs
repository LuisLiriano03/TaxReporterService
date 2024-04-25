﻿using System;
using System.Collections.Generic;
using TaxReporter.Entities;

namespace TaxReporter;

public partial class MenuRol
{
    public int MenuRolId { get; set; }

    public int? MenuId { get; set; }

    public int? RolId { get; set; }

    public virtual Menu? Menu { get; set; }

    public virtual Rol? Rol { get; set; }
}
