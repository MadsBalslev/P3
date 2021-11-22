using System;
using System.Collections.Generic;
using System.Linq;
using server.Entities;
namespace server.Services
{
    public class MetadataService
    {
        public MetadataService(databaseContext context)
        {
            _context = context;
        }
        private databaseContext _context;
        public Metadata GetTimer(int id)
        {
            Metadata metadata = _context.Metadatas.Find(id);

            if (metadata == null)
            {
                throw new NullReferenceException("Invalid value: cannot be null!");
            }

            return metadata;
        }
        public Object GetTimerJSON(int id)
        {

            Metadata md = GetTimer(id);
            return md.ToJSON();
        }

        public Metadata UpdateTimer(int id, Metadata metadata)
        {
            Metadata md = GetTimer(id);
            md.Timer = metadata.Timer;

            _context.SaveChanges();

            return md;
        }

        public Object UpdateTimerJSON(int id, Metadata md) => UpdateTimer(id, md).ToJSON();
    }
}