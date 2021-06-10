using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OsmQuality.RawModels.TempModel;

#nullable disable

namespace OsmQuality.RawModels
{
    public partial class country_qualityContext : DbContext
    {
        private readonly String _connectionCountry;
        public country_qualityContext(String countryCode)
        {
            _connectionCountry = countryCode;
        }

        public country_qualityContext()
        {
        }

        public country_qualityContext(DbContextOptions<country_qualityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AmenityLine> AmenityLines { get; set; }
        public virtual DbSet<AmenityPoint> AmenityPoints { get; set; }
        public virtual DbSet<AmenityPolygon> AmenityPolygons { get; set; }
        public virtual DbSet<BuildingPoint> BuildingPoints { get; set; }
        public virtual DbSet<BuildingPolygon> BuildingPolygons { get; set; }
        public virtual DbSet<IndoorLine> IndoorLines { get; set; }
        public virtual DbSet<IndoorPoint> IndoorPoints { get; set; }
        public virtual DbSet<IndoorPolygon> IndoorPolygons { get; set; }
        public virtual DbSet<InfrastructurePoint> InfrastructurePoints { get; set; }
        public virtual DbSet<LandusePoint> LandusePoints { get; set; }
        public virtual DbSet<LandusePolygon> LandusePolygons { get; set; }
        public virtual DbSet<LeisurePoint> LeisurePoints { get; set; }
        public virtual DbSet<LeisurePolygon> LeisurePolygons { get; set; }
        public virtual DbSet<NaturalLine> NaturalLines { get; set; }
        public virtual DbSet<NaturalPoint> NaturalPoints { get; set; }
        public virtual DbSet<NaturalPolygon> NaturalPolygons { get; set; }
        public virtual DbSet<PgosmFlex> PgosmFlices { get; set; }
        public virtual DbSet<PlaceLine> PlaceLines { get; set; }
        public virtual DbSet<PlacePoint> PlacePoints { get; set; }
        public virtual DbSet<PlacePolygon> PlacePolygons { get; set; }
        public virtual DbSet<PlanetOsmNode> PlanetOsmNodes { get; set; }
        public virtual DbSet<PlanetOsmRel> PlanetOsmRels { get; set; }
        public virtual DbSet<PlanetOsmWay> PlanetOsmWays { get; set; }
        public virtual DbSet<PoiLine> PoiLines { get; set; }
        public virtual DbSet<PoiPoint> PoiPoints { get; set; }
        public virtual DbSet<PoiPolygon> PoiPolygons { get; set; }
        public virtual DbSet<RoadLine> RoadLines { get; set; }
        public virtual DbSet<RoadPoint> RoadPoints { get; set; }
        public virtual DbSet<ShopPoint> ShopPoints { get; set; }
        public virtual DbSet<ShopPolygon> ShopPolygons { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TrafficLine> TrafficLines { get; set; }
        public virtual DbSet<TrafficPoint> TrafficPoints { get; set; }
        public virtual DbSet<TrafficPolygon> TrafficPolygons { get; set; }
        public virtual DbSet<WaterLine> WaterLines { get; set; }
        public virtual DbSet<WaterPoint> WaterPoints { get; set; }
        public virtual DbSet<WaterPolygon> WaterPolygons { get; set; }

        public DbSet<TagAggregation> TagAggregation { get; set; }
        public DbSet<AverageTags> AverageTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=" + _connectionCountry.ToLower() + ";Username=postgres;Password=osm");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("hstore")
                .HasPostgresExtension("postgis")
                .HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<TagAggregation>().HasNoKey();

            modelBuilder.Entity<AverageTags>().HasNoKey();
            
            modelBuilder.Entity<AmenityLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("amenity_line", "osm");

                entity.HasIndex(e => e.OsmId, "amenity_line_osm_id_idx");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Housenumber).HasColumnName("housenumber");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Postcode).HasColumnName("postcode");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Street).HasColumnName("street");
            });

            modelBuilder.Entity<AmenityPoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("amenity_point", "osm");

                entity.HasIndex(e => e.OsmId, "amenity_point_osm_id_idx");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Housenumber).HasColumnName("housenumber");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Postcode).HasColumnName("postcode");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Street).HasColumnName("street");
            });

            modelBuilder.Entity<AmenityPolygon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("amenity_polygon", "osm");

                entity.HasIndex(e => e.OsmId, "amenity_polygon_osm_id_idx");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Housenumber).HasColumnName("housenumber");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Postcode).HasColumnName("postcode");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Street).HasColumnName("street");
            });

            modelBuilder.Entity<BuildingPoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("building_point", "osm");

                entity.HasIndex(e => e.OsmId, "building_point_osm_id_idx");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Housenumber).HasColumnName("housenumber");

                entity.Property(e => e.Levels).HasColumnName("levels");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Operator).HasColumnName("operator");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmSubtype).HasColumnName("osm_subtype");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Postcode).HasColumnName("postcode");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Street).HasColumnName("street");

                entity.Property(e => e.Wheelchair).HasColumnName("wheelchair");
            });

            modelBuilder.Entity<BuildingPolygon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("building_polygon", "osm");

                entity.HasIndex(e => e.OsmId, "building_polygon_osm_id_idx");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Housenumber).HasColumnName("housenumber");

                entity.Property(e => e.Levels).HasColumnName("levels");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Operator).HasColumnName("operator");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmSubtype).HasColumnName("osm_subtype");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Postcode).HasColumnName("postcode");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Street).HasColumnName("street");

                entity.Property(e => e.Wheelchair).HasColumnName("wheelchair");
            });

            modelBuilder.Entity<IndoorLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("indoor_line", "osm");

                entity.HasIndex(e => e.OsmId, "indoor_line_osm_id_idx");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Door).HasColumnName("door");

                entity.Property(e => e.Entrance).HasColumnName("entrance");

                entity.Property(e => e.Highway).HasColumnName("highway");

                entity.Property(e => e.Layer).HasColumnName("layer");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Room).HasColumnName("room");
            });

            modelBuilder.Entity<IndoorPoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("indoor_point", "osm");

                entity.HasIndex(e => e.OsmId, "indoor_point_osm_id_idx");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Door).HasColumnName("door");

                entity.Property(e => e.Entrance).HasColumnName("entrance");

                entity.Property(e => e.Highway).HasColumnName("highway");

                entity.Property(e => e.Layer).HasColumnName("layer");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Room).HasColumnName("room");
            });

            modelBuilder.Entity<IndoorPolygon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("indoor_polygon", "osm");

                entity.HasIndex(e => e.OsmId, "indoor_polygon_osm_id_idx");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Door).HasColumnName("door");

                entity.Property(e => e.Entrance).HasColumnName("entrance");

                entity.Property(e => e.Highway).HasColumnName("highway");

                entity.Property(e => e.Layer).HasColumnName("layer");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Room).HasColumnName("room");
            });

            modelBuilder.Entity<InfrastructurePoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("infrastructure_point", "osm");

                entity.HasIndex(e => e.OsmId, "infrastructure_point_osm_id_idx");

                entity.Property(e => e.Ele).HasColumnName("ele");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Material).HasColumnName("material");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Operator).HasColumnName("operator");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmSubtype).HasColumnName("osm_subtype");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");
            });

            modelBuilder.Entity<LandusePoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("landuse_point", "osm");

                entity.HasIndex(e => e.OsmId, "landuse_point_osm_id_idx");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");
            });

            modelBuilder.Entity<LandusePolygon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("landuse_polygon", "osm");

                entity.HasIndex(e => e.OsmId, "landuse_polygon_osm_id_idx");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");
            });

            modelBuilder.Entity<LeisurePoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("leisure_point", "osm");

                entity.HasIndex(e => e.OsmId, "leisure_point_osm_id_idx");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");
            });

            modelBuilder.Entity<LeisurePolygon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("leisure_polygon", "osm");

                entity.HasIndex(e => e.OsmId, "leisure_polygon_osm_id_idx");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");
            });

            modelBuilder.Entity<NaturalLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("natural_line", "osm");

                entity.HasIndex(e => e.OsmId, "natural_line_osm_id_idx");

                entity.Property(e => e.Ele).HasColumnName("ele");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");
            });

            modelBuilder.Entity<NaturalPoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("natural_point", "osm");

                entity.HasIndex(e => e.OsmId, "natural_point_osm_id_idx");

                entity.Property(e => e.Ele).HasColumnName("ele");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");
            });

            modelBuilder.Entity<NaturalPolygon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("natural_polygon", "osm");

                entity.HasIndex(e => e.OsmId, "natural_polygon_osm_id_idx");

                entity.Property(e => e.Ele).HasColumnName("ele");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");
            });

            modelBuilder.Entity<PgosmFlex>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pgosm_flex", "osm");

                entity.Property(e => e.DefaultDate).HasColumnName("default_date");

                entity.Property(e => e.Osm2pgsqlVersion)
                    .IsRequired()
                    .HasColumnName("osm2pgsql_version");

                entity.Property(e => e.OsmDate)
                    .HasColumnType("date")
                    .HasColumnName("osm_date");

                entity.Property(e => e.PgosmFlexVersion)
                    .IsRequired()
                    .HasColumnName("pgosm_flex_version");

                entity.Property(e => e.ProjectUrl)
                    .IsRequired()
                    .HasColumnName("project_url");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnName("region");

                entity.Property(e => e.Srid)
                    .IsRequired()
                    .HasColumnName("srid");
            });

            modelBuilder.Entity<PlaceLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("place_line", "osm");

                entity.HasIndex(e => e.OsmId, "place_line_osm_id_idx");

                entity.Property(e => e.AdminLevel).HasColumnName("admin_level");

                entity.Property(e => e.Boundary).HasColumnName("boundary");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");
            });

            modelBuilder.Entity<PlacePoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("place_point", "osm");

                entity.HasIndex(e => e.OsmId, "place_point_osm_id_idx");

                entity.Property(e => e.AdminLevel).HasColumnName("admin_level");

                entity.Property(e => e.Boundary).HasColumnName("boundary");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");
            });

            modelBuilder.Entity<PlacePolygon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("place_polygon", "osm");

                entity.HasIndex(e => e.OsmId, "place_polygon_osm_id_idx");

                entity.Property(e => e.AdminLevel).HasColumnName("admin_level");

                entity.Property(e => e.Boundary).HasColumnName("boundary");

                entity.Property(e => e.MemberIds)
                    .HasColumnType("jsonb")
                    .HasColumnName("member_ids");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");
            });

            modelBuilder.Entity<PlanetOsmNode>(entity =>
            {
                entity.ToTable("planet_osm_nodes");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lon).HasColumnName("lon");
            });

            modelBuilder.Entity<PlanetOsmRel>(entity =>
            {
                entity.ToTable("planet_osm_rels");

                entity.HasIndex(e => e.Parts, "planet_osm_rels_parts_idx")
                    .HasMethod("gin");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Members).HasColumnName("members");

                entity.Property(e => e.Parts).HasColumnName("parts");

                entity.Property(e => e.RelOff).HasColumnName("rel_off");

                entity.Property(e => e.Tags).HasColumnName("tags");

                entity.Property(e => e.WayOff).HasColumnName("way_off");
            });

            modelBuilder.Entity<PlanetOsmWay>(entity =>
            {
                entity.ToTable("planet_osm_ways");

                entity.HasIndex(e => e.Nodes, "planet_osm_ways_nodes_idx")
                    .HasMethod("gin");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nodes)
                    .IsRequired()
                    .HasColumnName("nodes");

                entity.Property(e => e.Tags).HasColumnName("tags");
            });

            modelBuilder.Entity<PoiLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("poi_line", "osm");

                entity.HasIndex(e => e.OsmId, "poi_line_osm_id_idx");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Housenumber).HasColumnName("housenumber");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Operator).HasColumnName("operator");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmSubtype)
                    .IsRequired()
                    .HasColumnName("osm_subtype");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Postcode).HasColumnName("postcode");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Street).HasColumnName("street");
            });

            modelBuilder.Entity<PoiPoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("poi_point", "osm");

                entity.HasIndex(e => e.OsmId, "poi_point_osm_id_idx");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Housenumber).HasColumnName("housenumber");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Operator).HasColumnName("operator");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmSubtype)
                    .IsRequired()
                    .HasColumnName("osm_subtype");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Postcode).HasColumnName("postcode");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Street).HasColumnName("street");
            });

            modelBuilder.Entity<PoiPolygon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("poi_polygon", "osm");

                entity.HasIndex(e => e.OsmId, "poi_polygon_osm_id_idx");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Housenumber).HasColumnName("housenumber");

                entity.Property(e => e.MemberIds)
                    .HasColumnType("jsonb")
                    .HasColumnName("member_ids");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Operator).HasColumnName("operator");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmSubtype)
                    .IsRequired()
                    .HasColumnName("osm_subtype");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Postcode).HasColumnName("postcode");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Street).HasColumnName("street");
            });

            modelBuilder.Entity<RoadLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("road_line", "osm");

                entity.HasIndex(e => e.OsmId, "road_line_osm_id_idx");

                entity.Property(e => e.Bridge).HasColumnName("bridge");

                entity.Property(e => e.Layer).HasColumnName("layer");

                entity.Property(e => e.Major).HasColumnName("major");

                entity.Property(e => e.Maxspeed).HasColumnName("maxspeed");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Oneway).HasColumnName("oneway");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Ref).HasColumnName("ref");

                entity.Property(e => e.RouteCycle).HasColumnName("route_cycle");

                entity.Property(e => e.RouteFoot).HasColumnName("route_foot");

                entity.Property(e => e.RouteMotor).HasColumnName("route_motor");

                entity.Property(e => e.Tunnel).HasColumnName("tunnel");
            });

            modelBuilder.Entity<RoadPoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("road_point", "osm");

                entity.HasIndex(e => e.OsmId, "road_point_osm_id_idx");

                entity.Property(e => e.Bridge).HasColumnName("bridge");

                entity.Property(e => e.Layer).HasColumnName("layer");

                entity.Property(e => e.Maxspeed).HasColumnName("maxspeed");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Oneway).HasColumnName("oneway");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Ref).HasColumnName("ref");

                entity.Property(e => e.Tunnel).HasColumnName("tunnel");
            });

            modelBuilder.Entity<ShopPoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("shop_point", "osm");

                entity.HasIndex(e => e.OsmId, "shop_point_osm_id_idx");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.Brand).HasColumnName("brand");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Housenumber).HasColumnName("housenumber");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Operator).HasColumnName("operator");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmSubtype)
                    .IsRequired()
                    .HasColumnName("osm_subtype");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Postcode).HasColumnName("postcode");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Street).HasColumnName("street");

                entity.Property(e => e.Website).HasColumnName("website");

                entity.Property(e => e.Wheelchair).HasColumnName("wheelchair");
            });

            modelBuilder.Entity<ShopPolygon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("shop_polygon", "osm");

                entity.HasIndex(e => e.OsmId, "shop_polygon_osm_id_idx");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.Brand).HasColumnName("brand");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Housenumber).HasColumnName("housenumber");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Operator).HasColumnName("operator");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmSubtype)
                    .IsRequired()
                    .HasColumnName("osm_subtype");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Postcode).HasColumnName("postcode");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Street).HasColumnName("street");

                entity.Property(e => e.Website).HasColumnName("website");

                entity.Property(e => e.Wheelchair).HasColumnName("wheelchair");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tags", "osm");

                entity.HasIndex(e => new { e.GeomType, e.OsmId }, "tags_geom_type_osm_id_idx");

                entity.Property(e => e.GeomType)
                    .HasMaxLength(1)
                    .HasColumnName("geom_type");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.Tags)
                    .HasColumnType("jsonb")
                    .HasColumnName("tags");
            });

            modelBuilder.Entity<TrafficLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("traffic_line", "osm");

                entity.HasIndex(e => e.OsmId, "traffic_line_osm_id_idx");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmSubtype).HasColumnName("osm_subtype");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");
            });

            modelBuilder.Entity<TrafficPoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("traffic_point", "osm");

                entity.HasIndex(e => e.OsmId, "traffic_point_osm_id_idx");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmSubtype).HasColumnName("osm_subtype");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");
            });

            modelBuilder.Entity<TrafficPolygon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("traffic_polygon", "osm");

                entity.HasIndex(e => e.OsmId, "traffic_polygon_osm_id_idx");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmSubtype).HasColumnName("osm_subtype");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");
            });

            modelBuilder.Entity<WaterLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("water_line", "osm");

                entity.HasIndex(e => e.OsmId, "water_line_osm_id_idx");

                entity.Property(e => e.Boat).HasColumnName("boat");

                entity.Property(e => e.Bridge).HasColumnName("bridge");

                entity.Property(e => e.Layer).HasColumnName("layer");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmSubtype)
                    .IsRequired()
                    .HasColumnName("osm_subtype");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Tunnel).HasColumnName("tunnel");
            });

            modelBuilder.Entity<WaterPoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("water_point", "osm");

                entity.HasIndex(e => e.OsmId, "water_point_osm_id_idx");

                entity.Property(e => e.Boat).HasColumnName("boat");

                entity.Property(e => e.Bridge).HasColumnName("bridge");

                entity.Property(e => e.Layer).HasColumnName("layer");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmSubtype)
                    .IsRequired()
                    .HasColumnName("osm_subtype");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Tunnel).HasColumnName("tunnel");
            });

            modelBuilder.Entity<WaterPolygon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("water_polygon", "osm");

                entity.HasIndex(e => e.OsmId, "water_polygon_osm_id_idx");

                entity.Property(e => e.Boat).HasColumnName("boat");

                entity.Property(e => e.Bridge).HasColumnName("bridge");

                entity.Property(e => e.Layer).HasColumnName("layer");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OsmId).HasColumnName("osm_id");

                entity.Property(e => e.OsmSubtype)
                    .IsRequired()
                    .HasColumnName("osm_subtype");

                entity.Property(e => e.OsmType)
                    .IsRequired()
                    .HasColumnName("osm_type");

                entity.Property(e => e.Tunnel).HasColumnName("tunnel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
