using System;


namespace PayrollApp.Domain.Specifications
{

    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T o); //IC add
        bool IsSatisfiedBy(T o, ref string failedMessages);
        ISpecification<T> And(ISpecification<T> specification);
        ISpecification<T> Or(ISpecification<T> specification);
        ISpecification<T> Not(ISpecification<T> specification);
    }

    //IC add
    public abstract class Specification<T>
    {
        public abstract bool IsSatisfiedBy(T o);
        public abstract bool IsSatisfiedBy(T o, ref string failedMessages);
    }


    public abstract class CompositeSpecification<T> : Specification<T>, ISpecification<T>
    {
        //public abstract bool IsSatisfiedBy(T o);

        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }
        public ISpecification<T> Or(ISpecification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }
        public ISpecification<T> Not(ISpecification<T> specification)
        {
            return new NotSpecification<T>(specification);
        }
    }

    public class AndSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _leftSpecification = left;
            _rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return _leftSpecification.IsSatisfiedBy(o) && _rightSpecification.IsSatisfiedBy(o);
        }

        public override bool IsSatisfiedBy(T o, ref string failedMessages)
        {
            return _leftSpecification.IsSatisfiedBy(o, ref failedMessages) && _rightSpecification.IsSatisfiedBy(o, ref failedMessages);
        }
    }

    public class OrSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _leftSpecification = left;
            _rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return _leftSpecification.IsSatisfiedBy(o) || _rightSpecification.IsSatisfiedBy(o);
        }

        public override bool IsSatisfiedBy(T o, ref string failedMessages)
        {
            return _leftSpecification.IsSatisfiedBy(o, ref failedMessages) || _rightSpecification.IsSatisfiedBy(o, ref failedMessages);
        }
    }

    public class NotSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> _specification;

        public NotSpecification(ISpecification<T> spec)
        {
            _specification = spec;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return !_specification.IsSatisfiedBy(o);
        }

        public override bool IsSatisfiedBy(T o, ref string failedMessages)
        {
            return !_specification.IsSatisfiedBy(o, ref failedMessages);
        }
    }

    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        private readonly Func<T, bool> _expression;
        private readonly string _failedMessage; //IC add

        public ExpressionSpecification(
            Func<T, bool> expression,
            string failedMessage)
        {
            if (expression == null)
                throw new ArgumentNullException();
            _expression = expression;
            _failedMessage = failedMessage;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return _expression(o);
        }

        public override bool IsSatisfiedBy(T o, ref string failedMessages)
        {
            bool result = _expression(o);
            if (!result)
            {
                if (failedMessages.Length > 0)
                    failedMessages += ". ";
                failedMessages += _failedMessage;
            }
            return result;
        }

    }

}
