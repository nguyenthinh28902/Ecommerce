using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class WebUser
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string UserImage { get; set; } = null!;

    public bool? IsDelete { get; set; }

    public bool? IsActive { get; set; }

    public int? CreateUser { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<WebRoleUser> WebRoleUsers { get; set; } = new List<WebRoleUser>();
}
