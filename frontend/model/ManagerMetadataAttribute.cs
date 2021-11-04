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
                throw new ArgumentException();
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
                throw new ArgumentException();
        }
    }

    public FormRepresentation EditFormRepresentation
    {
        get => _editFormRepresentation;
        private set
        {
            if (EditableBy == AccessLevel.None && value != FormRepresentation.None)
            {
                throw new ArgumentException();
            }
            _editFormRepresentation = value;
        }
    }

    private AccessLevel _viewableBy = AccessLevel.None;
    private AccessLevel _editableBy = AccessLevel.None;
    private FormRepresentation _editFormRepresentation = FormRepresentation.None;


    public ManagerMetadataAttribute(string headerDisplayname, AccessLevel viewableBy, AccessLevel editableby, FormRepresentation formRepresentation)
    {
        HeaderDisplayname = headerDisplayname;
        ViewableBy = viewableBy;
        EditableBy = editableby;
        EditFormRepresentation = formRepresentation;
    }
}