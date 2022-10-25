using Microsoft.EntityFrameworkCore;

namespace App.EntityFrameworkCore.Mapping
{
    public interface IMappingConfiguration
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}