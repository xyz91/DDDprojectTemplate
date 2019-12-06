using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq;

namespace MeidPlus.Repository.MongoRepository.Mapping
{
   public class MDBHolidayMapping
    {
      
        public static void Register() {
            BsonClassMap.RegisterClassMap<Entity<string>>(a=> {
                a.AutoMap();
                a.MapIdProperty(p => p.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer().
                    WithRepresentation(BsonType.ObjectId));
                a.SetIgnoreExtraElements(true);
                a.SetIgnoreExtraElementsIsInherited(true);
            });
            BsonClassMap.RegisterClassMap<Entity<int>>(a => {
                a.AutoMap();
                a.MapIdProperty(p => p.Id);                   
                a.SetIgnoreExtraElements(true);
                a.SetIgnoreExtraElementsIsInherited(true);
            });
            BsonClassMap.RegisterClassMap<MDBYearHoliday>(a => {
                a.AutoMap();              
                    //a.MapIdProperty(p => p.Id)
                    //    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    //    .SetSerializer(new StringSerializer().
                    //    WithRepresentation(BsonType.ObjectId));
               // a.SetIgnoreExtraElements(true);
                
            });
            BsonClassMap.RegisterClassMap<MDBTest>();
        }


        

    }


    public class Map<T> {
        public static MemberInfo GetMemberInfoFromLambda<TMember>(Expression<Func<T, TMember>> memberLambda)
        {
            Expression body = memberLambda.Body;
            MemberExpression memberExpression;
            switch (body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    memberExpression = (MemberExpression)body;
                    break;
                case ExpressionType.Convert:
                    memberExpression = (MemberExpression)((UnaryExpression)body).Operand;
                    break;
                default:
                    throw new BsonSerializationException("Invalid lambda expression");
            }
            MemberInfo memberInfo = memberExpression.Member;

            

            if (memberInfo is PropertyInfo)
            {
                if (memberInfo.DeclaringType.GetTypeInfo().IsInterface)
                {
                    memberInfo = FindPropertyImplementation((PropertyInfo)memberInfo, typeof(T));
                }
            }
            else if (!(memberInfo is FieldInfo))
            {
                throw new BsonSerializationException("Invalid lambda expression");
            }
            return memberInfo;
        }
        private static PropertyInfo FindPropertyImplementation(PropertyInfo interfacePropertyInfo, Type actualType)
        {
            _ = interfacePropertyInfo.DeclaringType;
            TypeInfo typeInfo = actualType.GetTypeInfo();
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            IEnumerable<PropertyInfo> source = typeInfo.GetMembers(bindingFlags).OfType<PropertyInfo>();
            string explicitlyImplementedPropertyName = (interfacePropertyInfo.DeclaringType.FullName + "." + interfacePropertyInfo.Name).Replace("+", ".");
            PropertyInfo propertyInfo = source.Where((PropertyInfo p) => p.Name == explicitlyImplementedPropertyName).SingleOrDefault();
            if ((object)propertyInfo != null)
            {
                return propertyInfo;
            }
            PropertyInfo propertyInfo2 = source.Where((PropertyInfo p) => p.Name == interfacePropertyInfo.Name && (object)p.PropertyType == interfacePropertyInfo.PropertyType).SingleOrDefault();
            if ((object)propertyInfo2 != null)
            {
                return propertyInfo2;
            }
            throw new BsonSerializationException("Unable to find property info for property: '" + interfacePropertyInfo.Name + "'.");
        }
    }
}
