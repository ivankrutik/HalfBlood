using System.Net;

namespace Halfblood.Common
{
    public enum TypeActionInSystem : byte
    {
        NonStandardAction = 0,
        TheStandardAddition = 1,
        StandardCorrection = 2,
        StandardDeletion = 3,
        StandardMoveToTheDirectory = 4,
        StandardMoveFromTheDirectory = 5,
        StandardMoveInTheHierarchy = 6,
        TheChoiceOnTheBasisOfSection = 7,
        StandardDischargeInExcel = 8,
        StandardExport = 9,
        StandardSpecificationPreview = 10,
        TheOpeningSection = 11,
        TheStandardFormOfEds = 12,
        StandardDigitalSignatureVerification = 13,
        TheStandardRemovalOfEds = 14
    }

    public enum DirectionFind : byte
    {
        Forward = 0,
        Backward = 1,
        Full = 2
    }

    public enum Sense: byte
    {
        Emerge = 0,
        Falling = 1,
        Full=2
    }

    public enum DepartmentOrderClosedRequirementType : byte
    {
        GT=0
    }
}
