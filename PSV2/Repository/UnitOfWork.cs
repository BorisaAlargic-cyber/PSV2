using System;
using PSV2.Core;
using PSV2.Model;

namespace PSV2.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ModelContext context;

        public UnitOfWork(ModelContext context)
        {
            this.context = context;
            Users = new UserRepository(this.context);
            Apointment = new ApointmentRepository(this.context);
            Feedback = new FeedbackRepository(this.context);
            Instruction = new InstructionRepository(this.context);
            Visits = new VisitRepository(this.context);
            Drugs = new DrugRepository(this.context);
            Recepie = new RecepieRepository(this.context);

        }
        public IUserRepository Users { get; private set; }
        public IApointmentRepository Apointment { get; private set; }
        public IFeedbackRepository Feedback { get; private set; }
        public IInstructionRepository Instruction { get; private set; }

        public IVisitRepository Visits { get; private set; }
        public IDrugRepository Drugs { get; private set; }
        public IRecepieRepository Recepie { get; private set; }

        public ModelContext Context
        {
            get { return context; }
        }
        public int Complete()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
