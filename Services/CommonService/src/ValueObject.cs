namespace Fina.Services.CommonService;

public abstract class ValueObject {
	protected static bool EqualOperator(ValueObject left, ValueObject right) {
		if(ReferenceEquals(left, null) ^ ReferenceEquals(right, null)) {
			return false;
		}
		return ReferenceEquals(left, right) || left.Equals(right);
	}

	protected static bool NotEqualOperator(ValueObject left, ValueObject right) {
		return !EqualOperator(left, right);
	}

	protected abstract IEnumerable<object> GetAtomic();

	public override bool Equals(object obj) {
		if(obj == null || obj.GetType() != GetType()) {
			return false;
		}

		var other = (ValueObject)obj;

		return this.GetAtomic().SequenceEqual(other.GetAtomic());
	}

	public override int GetHashCode() {
		return GetAtomic()
			.Select(x => x != null ? x.GetHashCode() : 0)
			.Aggregate((x, y) => x ^ y);
	}


}