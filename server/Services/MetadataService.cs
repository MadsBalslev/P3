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
        public Metadatum GetTimer(int id)
        {
            Metadatum metadata = _context.Metadata.Find(id);

            if (metadata == null)
            {
                throw new NullReferenceException("Invalid value: cannot be null!");
            }

            return metadata;
        }
        public Object GetTimerJSON(int id)
        {

            Metadatum md = GetTimer(id);
            return md.ToJSON();
        }

    }
}