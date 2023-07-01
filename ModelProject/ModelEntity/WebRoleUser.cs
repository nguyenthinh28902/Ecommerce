using System;
using System.Collections.Generic;

namespace ModelEntity.ModelEntity;

public partial class WebRoleUser
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual WebRole Role { get; set; } = null!;

    public virtual WebUser User { get; set; } = null!;
}
