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
using MediPlus.Domain.Model.BaseModel;

namespace MeidPlus.Repository.MongoRepository.Mapping
{
   public class MongodbMapping
    {
      /// <summary>
      /// 映射mongodb数据
      /// </summary>
        public static void Register() {
            BsonClassMap.RegisterClassMap<Obj>(a => {
                a.AutoMap();
                a.UnmapProperty(b=>b.EventDatas);
                a.SetIgnoreExtraElements(true);
                a.SetIgnoreExtraElementsIsInherited(true);
                
            });
            BsonClassMap.RegisterClassMap<Entity<string>>(a=> {
                a.AutoMap();
               // a.MapIdField("_id").SetElementName("Id")
                a.MapIdProperty(p => p.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer().
                    WithRepresentation(BsonType.ObjectId));
            });
            BsonClassMap.RegisterClassMap<Entity<int>>(a => {
                a.AutoMap();
               // a.MapIdField("_id").SetElementName("Id");
                a.MapIdProperty(p => p.Id);                   
            });

            BsonClassMap.RegisterClassMap<MediTest>(a=> {
                a.AutoMap();
                a.MapField("_mediTestNodes").SetElementName("MediTestNodes");
                a.UnmapProperty(b=>b.MediTestNodes);
            });
            BsonClassMap.RegisterClassMap<MediTestNode>(a=> {
                a.AutoMap();
                a.UnmapProperty(b=>b.MediTest);
                a.UnmapProperty(b=>b.MediTestId);
            });

           var types = typeof(Obj).Assembly.GetTypes().Where(a=>typeof(Obj).IsAssignableFrom(a));
            foreach (var item in types)
            {
                if (!BsonClassMap.IsClassMapRegistered(item))
                {
                    BsonClassMap.RegisterClassMap(new BsonClassMap(item));
                }
            }
            
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
