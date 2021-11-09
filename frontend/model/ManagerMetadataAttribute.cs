using System;

[AttributeUsage(AttributeTargets.Property)]
public class ManagerMetadataAttribute : Attribute
{
    public string HeaderDisplayname { get; private set; } = "nil";

    public AccessLevel ViewableBy
    {
        get => _viewableBy;
        private set
        {
            if (value <= EditableBy)
                _viewableBy = value;
            else
                throw new ArgumentException("Property ManagerMetaDataAttribute can't have ViewableBy > EditableBy");
        }
    }

    public AccessLevel EditableBy
    {
        get => _editableBy;
        private set
        {
            if (value >= ViewableBy)
                _editableBy = value;
            else
                throw new ArgumentException("Property ManagerMetaDataAttribute can't have ViewableBy > EditableBy");
        }
    }

    private AccessLevel _viewableBy = AccessLevel.None;
    private AccessLevel _editableBy = AccessLevel.None;

    public ManagerMetadataAttribute(string headerDisplayname, AccessLevel viewableBy, AccessLevel editableby)
    {
        HeaderDisplayname = headerDisplayname;
        ViewableBy = viewableBy;
        EditableBy = editableby;
    }
}