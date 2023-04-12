using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;

namespace SelectAllRowsInGroup.Data {
    public class CriteriaStringToLowerConverter : ClientCriteriaVisitorBase {
        public static CriteriaOperator Convert(CriteriaOperator source) {
            return new CriteriaStringToLowerConverter().AcceptOperator(source);
        }

        protected override CriteriaOperator Visit(FunctionOperator theOperator) {
            var shouldConvertToLower = SearchInStringOperatorType(theOperator.OperatorType) &&
                                       theOperator.Operands.Count == 2 &&
                                       theOperator.Operands[0] is OperandProperty &&
                                       theOperator.Operands[1] is OperandValue;

            if (!shouldConvertToLower)
                return theOperator;

            var opProp = (OperandProperty)theOperator.Operands[0];
            var opValue = (OperandValue)theOperator.Operands[1];

            var lowerCriteria = new FunctionOperator(FunctionOperatorType.Lower, opProp);
            var lowerValue = new OperandValue(opValue.Value.ToString().ToLower());
            return new FunctionOperator(theOperator.OperatorType, lowerCriteria, lowerValue);
        }

        bool SearchInStringOperatorType(FunctionOperatorType opType) {
            switch (opType) {
                case FunctionOperatorType.StartsWith:
                case FunctionOperatorType.EndsWith:
                case FunctionOperatorType.Contains:
                    return true;
            }
            return false;
        }

        protected CriteriaOperator AcceptOperator(CriteriaOperator theOperator) {
            if (theOperator is null)
                return null;
            return theOperator.Accept(this);
        }
    }
}
