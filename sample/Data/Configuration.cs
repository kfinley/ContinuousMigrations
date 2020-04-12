using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data {
    public class Configuration<T> : IEntityTypeConfiguration<T>
        where T : class {

        Action<EntityTypeBuilder<T>> tableConfiguration;

        public Configuration(Action<EntityTypeBuilder<T>> tableConfiguration = null) {
            this.tableConfiguration = tableConfiguration;
        }

        public void Configure(EntityTypeBuilder<T> builder) {

            builder.ToTable(typeof(T).Name);

            tableConfiguration?.Invoke(builder);
        }
    }
}