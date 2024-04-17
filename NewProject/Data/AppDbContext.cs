


namespace NewProject.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<AcceptedItem> AcceptedItems { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<NeededItem> NeededItems { get; set; }
        public DbSet<Offer> Offers {  get; set; }
        public DbSet<SelectionCommittee> SelectionCommittees { get; set; }
        public DbSet<SelectionCommitteeMember> SelectionCommitteeMembers { get; set; }
        public DbSet<SpecifictionCommittee> SpecifictionCommittees { get; set; }
        public DbSet<SpecifictionCommitteeMember> SpecifictionCommitteeMembers { get; set; }
        public DbSet<StepnItem> StepnItems { get; set; }
        public DbSet<TechnicalCommittee> TechnicalCommittees { get; set; }
        public DbSet<TechnicalCommitteeMember> TechnicalCommitteeMembers { get; set; }
        public DbSet<Tender> Tenders { get; set; }  
        public DbSet<ValidItem> ValidItems { get; set; }
        public DbSet<ValidItemOffer> ValidItemOffers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SelectionCommitteeMember>().HasKey(x => new { x.MemberId, x.SelectionCommitteeId });
            modelBuilder.Entity<SpecifictionCommitteeMember>().HasKey(x=>new {x.MemberId , x.SpecifictionCommitteeId});
            modelBuilder.Entity<TechnicalCommitteeMember>().HasKey(x => new { x.MemberId, x.TechnicalCommitteeId });
            modelBuilder.Entity<ValidItemOffer>().HasKey(x=>new { x.OfferId , x.ValidItemId  });
            modelBuilder.Entity<Tender>().HasKey(x => x.Id);
            modelBuilder.Entity<Member>().HasData(new Member[]
            {
                new Member{Id=1 , Name = "Ahmed Mohamed"       , Password="Ahmed000@111" },
                new Member{Id=2 , Name = "Ahmed Shapaan"       , Password="Ahmed000@111" },
                new Member{Id=3 , Name = "Ahmed Tamer"         , Password="Ahmed000@111" },
                new Member{Id=4 , Name = "Safwa Mohamed"       , Password="Safwa000@111" },
                new Member{Id=5 , Name = "Sohila Amr"         , Password="Sohila000@111" },
                new Member{Id=6 , Name = "Yasmine Abdelrhman" ,Password="Yasmine000@111" },
                new Member{Id=7 , Name = "Zaid Adel"            , Password="Zaid000@111" },
                new Member{Id=8 , Name = "Amal Sabry"           , Password="Amal000@111" },
                new Member{Id=9 , Name = "Tarek Elsheshtawy"   , Password="Tarek000@111" },
                new Member{Id=10 , Name = "Amainy Saaed"       , Password="Amainy000@111" },
                new Member{Id=11 , Name = "Fady Fady"            , Password="Fady000@111" },
                new Member{Id=12 , Name = "Mohamed Abdelfataah",Password="Mohamed000@111" },
                new Member{Id=13 , Name = "Karam Karam"         , Password="Ahmed000@111" },
                new Member{Id=14 , Name = "Ahmed Shalaby"       , Password="Ahmed000@111" },
                new Member{Id=15 , Name = "Ahmed Taha"          , Password="Ahmed000@111"  },
                new Member{Id=16 , Name = "Mahmmud Ghonam" },
                new Member{Id=17 , Name = "Rayan Ghonam" },
                new Member{Id=18 , Name = "Yousef Hiatham" },
                new Member{Id=19 , Name = "Ahmed Hosny" }
            });
            modelBuilder.Entity<Vendor>().HasData(new Vendor[]
           {
                new Vendor{id=1 , Name = "Ahmed Shapaan"      },
                new Vendor{id=2 , Name = "Safwa Mohamed"      },
                new Vendor{id=3 , Name = "Ahmed Mohamed"      },
                new Vendor{id=4 , Name = "Sohila Amr"         },
                new Vendor{id=5 , Name = "Amal Sabry"         },
                new Vendor{id=6 , Name = "Yasmine Abdelrhman" },
                new Vendor{id=7 , Name = "Ahmed Ramadan"      },
                new Vendor{id=8 , Name = "Zaid Adel"          },
           });
        }
    }
}
