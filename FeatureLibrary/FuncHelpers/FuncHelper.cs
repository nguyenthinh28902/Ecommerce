using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

public static class GT<TModel>
{
    /// <summary>
    /// get DisplayAttribute Name of a property of Type
    /// </summary>
    public static string Display<TProperty>(Expression<Func<TModel, TProperty>> f)
    {
        var exp = f.Body as MemberExpression;
        var property = exp.Expression.Type.GetProperty(exp.Member.Name);
        var attr = property?.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
        return attr?.GetName() ?? exp.Member.Name;
    }
}

/// <summary>
/// global type handling helper
/// </summary>
public static class GT
{
    /// <summary>
    /// get DisplayAttribute Name of a property of a model
    /// </summary>
    public static string Display<TProperty>(Expression<Func<TProperty>> f)
    {
        var exp = f.Body as MemberExpression;
        var property = exp.Expression.Type.GetProperty(exp.Member.Name);
        var attr = property?.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
        return attr?.GetName() ?? exp.Member.Name;
    }
}
