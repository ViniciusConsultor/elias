using FluentNHibernate.Conventions;

namespace Alfa.Core.Mapper
{
    public class ConcorrencyConvention : IVersionConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IVersionInstance instance)
        {
            instance.Column("RowVersion");
            instance.Not.Nullable();
            instance.UnsavedValue("0");
            instance.Default(1);
        }
    }
}