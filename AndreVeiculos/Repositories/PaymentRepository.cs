using Models;

namespace Repositories
{
    public class PaymentRepository : BaseRepository
    {

        public override int Insert(Model model)
        {
            Payment payment = (Payment)model;

            if (payment == null)
                throw new Exception($"Tipo '{model.GetType()}' não aceito por PaymentRepository");

            if (payment.Card != null)
                base.Insert(payment.Card);
            else if (payment.PaymentSlip != null)
                base.Insert(payment.PaymentSlip);
            else if (payment.Pix != null)
                base.Insert(payment.Pix);
            else
                throw new Exception($"Nenhum método de pagamento fornecido");

            return base.Insert(model);
        }

    }
}
