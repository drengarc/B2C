using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Data.Objects;
using System.Collections;

namespace Prodma.DataAccessB2C
{
    public static class ExtensionMethods
    {
        private static Expression<Func<T, bool>> BuildFilterByExamplePredicate<T>(T example, params string[] discardedProperties)
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            Expression body = null;
            ParameterExpression lambdaParameter = Expression.Parameter(typeof(T), "__ENTITY__");
            foreach (PropertyInfo property in properties)
            {
                Expression lambdaProperty;
                if (discardedProperties.Contains(property.Name))
                    continue;
                Type propertyType = property.PropertyType;
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition().IsAssignableFrom(typeof(System.Data.Objects.DataClasses.EntityCollection<>)))
                    continue;
                if (property.GetValue(example, null) == null)
                    continue;
                if (property.PropertyType.Name == "Int32")
                {
                    if (Convert.ToInt32(property.GetValue(example, null)) == 0)
                        continue;
                }
                if (property.PropertyType.Name == "Decimal")
                {
                    if (Convert.ToInt32(property.GetValue(example, null)) == 0)
                        continue;
                }
                if (property.PropertyType.Name == "Byte")
                {
                    if (Convert.ToInt32(property.GetValue(example, null)) == 0)
                        continue;
                }
                if (property.PropertyType.Name == "DateTime")
                {
                    if (Convert.ToString(property.GetValue(example, null)) == "01.01.0001 00:00:00")
                        continue;
                }
                if (property.PropertyType.Name == "DateTimeOffset")
                {
                    if (Convert.ToString(property.GetValue(example, null)) == "01.01.0001 00:00:00 +00:00")
                        continue;
                }
                if (property.PropertyType.Name == "Nullable`1")
                {
                    lambdaProperty = Expression.Property(lambdaParameter, property.Name);
                    lambdaProperty = Expression.Convert(lambdaProperty, property.GetValue(example, null).GetType());
                }
                else
                {
                   lambdaProperty = Expression.Property(lambdaParameter, property.Name);
                }

                ConstantExpression constant = Expression.Constant(property.GetValue(example, null));
                BinaryExpression equal = Expression.Equal(lambdaProperty, constant);
                if(body == null)
                    body = equal;
                else
                    body = Expression.And(body, equal);
            }
            Expression<Func<T, bool>> lambdaExpression = Expression.Lambda<Func<T, bool>>(body, lambdaParameter);
            return lambdaExpression;
        }

        public static IQueryable<T> WhereByExample<T>(this IQueryable<T> instance, T example, params string[] discardedProperties) where T : class
        {
            return instance.Where(BuildFilterByExamplePredicate(example, discardedProperties));
        }
        public static IEnumerable<T> SortByExample<T>(this IEnumerable<T> source, string sortExpression)
        {
            string[] sortParts = sortExpression.Split(' ');
            var param = Expression.Parameter(typeof(T), string.Empty);
            try
            {
                var property = Expression.Property(param, sortParts[0]);
                var sortLambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), param);

                if (sortParts.Length > 1 && sortParts[1].Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    return source.AsQueryable<T>().OrderByDescending<T, object>(sortLambda);
                }
                return source.AsQueryable<T>().OrderBy<T, object>(sortLambda);
            }
            catch (ArgumentException)
            {
                return source;
            }
            //IEnumerable<User> sortedUsersIEnumerable = users.Sort<User>("ID desc"); 
            //Or
            //List<User> sortedUsersList = users.Sort<User>("Name").ToList();
        }

      

    }
}
