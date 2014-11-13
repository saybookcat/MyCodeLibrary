
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo
{
    public class IocContainer
    {
        private readonly Dictionary<Type, Type> _dependencyMap = new Dictionary<Type, Type>();

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public void Register<TFrom, TTo>()
        {
            _dependencyMap.Add(typeof(TFrom), typeof(TTo));
        }

       /// <summary>
       /// 获取依赖对象
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
        private object Resolve(Type type)
        {
            Type resolvedType = LookUpDependency(type);
            ConstructorInfo constructorInfo = resolvedType.GetConstructors().First();
            ParameterInfo[] parameters = constructorInfo.GetParameters();

            if (!parameters.Any())
            {
                return Activator.CreateInstance(resolvedType);
            }
            else
            {
                return constructorInfo.Invoke(ResolverParameters(
                    parameters).ToArray());
            }
        }

        /// <summary>
        /// 查找依赖
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private Type LookUpDependency(Type type)
        {
            return _dependencyMap[type];
        }


        private IEnumerable<object> ResolverParameters(IEnumerable<ParameterInfo> parameters)
        {
            return parameters.Select(p => Resolve(p.ParameterType)).ToList();
        }
    }
}
