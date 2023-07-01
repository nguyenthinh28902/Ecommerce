using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class WebRole
{
    public int Id { get; set; }

    public string RoleCode { get; set; } = null!;

    public string RoleDisPlay { get; set; } = null!;

    public string? RoleDescription { get; set; }

    public bool? IsDelete { get; set; }

    public bool? IsActive { get; set; }

    public int? CreateUser { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<WebRoleUser> WebRoleUsers { get; set; } = new List<WebRoleUser>();
}
