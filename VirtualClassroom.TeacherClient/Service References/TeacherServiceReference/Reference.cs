﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VirtualClassroom.TeacherClient.TeacherServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Teacher", Namespace="http://schemas.datacontract.org/2004/07/VirtualClassroom.Services")]
    [System.SerializableAttribute()]
    public partial class Teacher : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MiddleNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordHashField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private VirtualClassroom.TeacherClient.TeacherServiceReference.Subject[] SubjectsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MiddleName {
            get {
                return this.MiddleNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MiddleNameField, value) != true)) {
                    this.MiddleNameField = value;
                    this.RaisePropertyChanged("MiddleName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PasswordHash {
            get {
                return this.PasswordHashField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordHashField, value) != true)) {
                    this.PasswordHashField = value;
                    this.RaisePropertyChanged("PasswordHash");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public VirtualClassroom.TeacherClient.TeacherServiceReference.Subject[] Subjects {
            get {
                return this.SubjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.SubjectsField, value) != true)) {
                    this.SubjectsField = value;
                    this.RaisePropertyChanged("Subjects");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Subject", Namespace="http://schemas.datacontract.org/2004/07/VirtualClassroom.Services")]
    [System.SerializableAttribute()]
    public partial class Subject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private VirtualClassroom.TeacherClient.TeacherServiceReference.Class[] ClassesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private VirtualClassroom.TeacherClient.TeacherServiceReference.Lesson[] LessonsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TeacherIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public VirtualClassroom.TeacherClient.TeacherServiceReference.Class[] Classes {
            get {
                return this.ClassesField;
            }
            set {
                if ((object.ReferenceEquals(this.ClassesField, value) != true)) {
                    this.ClassesField = value;
                    this.RaisePropertyChanged("Classes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public VirtualClassroom.TeacherClient.TeacherServiceReference.Lesson[] Lessons {
            get {
                return this.LessonsField;
            }
            set {
                if ((object.ReferenceEquals(this.LessonsField, value) != true)) {
                    this.LessonsField = value;
                    this.RaisePropertyChanged("Lessons");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TeacherId {
            get {
                return this.TeacherIdField;
            }
            set {
                if ((this.TeacherIdField.Equals(value) != true)) {
                    this.TeacherIdField = value;
                    this.RaisePropertyChanged("TeacherId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Class", Namespace="http://schemas.datacontract.org/2004/07/VirtualClassroom.Services")]
    [System.SerializableAttribute()]
    public partial class Class : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LetterField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private VirtualClassroom.TeacherClient.TeacherServiceReference.Student[] StudentsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private VirtualClassroom.TeacherClient.TeacherServiceReference.Subject[] SubjectsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Letter {
            get {
                return this.LetterField;
            }
            set {
                if ((object.ReferenceEquals(this.LetterField, value) != true)) {
                    this.LetterField = value;
                    this.RaisePropertyChanged("Letter");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Number {
            get {
                return this.NumberField;
            }
            set {
                if ((this.NumberField.Equals(value) != true)) {
                    this.NumberField = value;
                    this.RaisePropertyChanged("Number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public VirtualClassroom.TeacherClient.TeacherServiceReference.Student[] Students {
            get {
                return this.StudentsField;
            }
            set {
                if ((object.ReferenceEquals(this.StudentsField, value) != true)) {
                    this.StudentsField = value;
                    this.RaisePropertyChanged("Students");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public VirtualClassroom.TeacherClient.TeacherServiceReference.Subject[] Subjects {
            get {
                return this.SubjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.SubjectsField, value) != true)) {
                    this.SubjectsField = value;
                    this.RaisePropertyChanged("Subjects");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Lesson", Namespace="http://schemas.datacontract.org/2004/07/VirtualClassroom.Services")]
    [System.SerializableAttribute()]
    public partial class Lesson : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentFilenameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] HomeworkContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> HomeworkDeadlineField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HomeworkFilenameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private VirtualClassroom.TeacherClient.TeacherServiceReference.Homework[] HomeworksField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SubjectIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ContentFilename {
            get {
                return this.ContentFilenameField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentFilenameField, value) != true)) {
                    this.ContentFilenameField = value;
                    this.RaisePropertyChanged("ContentFilename");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] HomeworkContent {
            get {
                return this.HomeworkContentField;
            }
            set {
                if ((object.ReferenceEquals(this.HomeworkContentField, value) != true)) {
                    this.HomeworkContentField = value;
                    this.RaisePropertyChanged("HomeworkContent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> HomeworkDeadline {
            get {
                return this.HomeworkDeadlineField;
            }
            set {
                if ((this.HomeworkDeadlineField.Equals(value) != true)) {
                    this.HomeworkDeadlineField = value;
                    this.RaisePropertyChanged("HomeworkDeadline");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string HomeworkFilename {
            get {
                return this.HomeworkFilenameField;
            }
            set {
                if ((object.ReferenceEquals(this.HomeworkFilenameField, value) != true)) {
                    this.HomeworkFilenameField = value;
                    this.RaisePropertyChanged("HomeworkFilename");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public VirtualClassroom.TeacherClient.TeacherServiceReference.Homework[] Homeworks {
            get {
                return this.HomeworksField;
            }
            set {
                if ((object.ReferenceEquals(this.HomeworksField, value) != true)) {
                    this.HomeworksField = value;
                    this.RaisePropertyChanged("Homeworks");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SubjectId {
            get {
                return this.SubjectIdField;
            }
            set {
                if ((this.SubjectIdField.Equals(value) != true)) {
                    this.SubjectIdField = value;
                    this.RaisePropertyChanged("SubjectId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Student", Namespace="http://schemas.datacontract.org/2004/07/VirtualClassroom.Services")]
    [System.SerializableAttribute()]
    public partial class Student : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ClassIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EGNField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private VirtualClassroom.TeacherClient.TeacherServiceReference.Homework[] HomeworksField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MiddleNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordHashField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ClassId {
            get {
                return this.ClassIdField;
            }
            set {
                if ((this.ClassIdField.Equals(value) != true)) {
                    this.ClassIdField = value;
                    this.RaisePropertyChanged("ClassId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EGN {
            get {
                return this.EGNField;
            }
            set {
                if ((object.ReferenceEquals(this.EGNField, value) != true)) {
                    this.EGNField = value;
                    this.RaisePropertyChanged("EGN");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public VirtualClassroom.TeacherClient.TeacherServiceReference.Homework[] Homeworks {
            get {
                return this.HomeworksField;
            }
            set {
                if ((object.ReferenceEquals(this.HomeworksField, value) != true)) {
                    this.HomeworksField = value;
                    this.RaisePropertyChanged("Homeworks");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MiddleName {
            get {
                return this.MiddleNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MiddleNameField, value) != true)) {
                    this.MiddleNameField = value;
                    this.RaisePropertyChanged("MiddleName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PasswordHash {
            get {
                return this.PasswordHashField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordHashField, value) != true)) {
                    this.PasswordHashField = value;
                    this.RaisePropertyChanged("PasswordHash");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Homework", Namespace="http://schemas.datacontract.org/2004/07/VirtualClassroom.Services")]
    [System.SerializableAttribute()]
    public partial class Homework : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LessonIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<float> MarkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StudentIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LessonId {
            get {
                return this.LessonIdField;
            }
            set {
                if ((this.LessonIdField.Equals(value) != true)) {
                    this.LessonIdField = value;
                    this.RaisePropertyChanged("LessonId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<float> Mark {
            get {
                return this.MarkField;
            }
            set {
                if ((this.MarkField.Equals(value) != true)) {
                    this.MarkField = value;
                    this.RaisePropertyChanged("Mark");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int StudentId {
            get {
                return this.StudentIdField;
            }
            set {
                if ((this.StudentIdField.Equals(value) != true)) {
                    this.StudentIdField = value;
                    this.RaisePropertyChanged("StudentId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TeacherServiceReference.ITeacherService")]
    public interface ITeacherService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITeacherService/LoginTeacher", ReplyAction="http://tempuri.org/ITeacherService/LoginTeacherResponse")]
        VirtualClassroom.TeacherClient.TeacherServiceReference.Teacher LoginTeacher(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITeacherService/AddLesson", ReplyAction="http://tempuri.org/ITeacherService/AddLessonResponse")]
        void AddLesson(VirtualClassroom.TeacherClient.TeacherServiceReference.Lesson lesson);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITeacherService/GetHomeworksByTeacher", ReplyAction="http://tempuri.org/ITeacherService/GetHomeworksByTeacherResponse")]
        VirtualClassroom.TeacherClient.TeacherServiceReference.Homework[] GetHomeworksByTeacher(int teacherId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITeacherService/GetLessonsByTeacher", ReplyAction="http://tempuri.org/ITeacherService/GetLessonsByTeacherResponse")]
        VirtualClassroom.TeacherClient.TeacherServiceReference.Lesson[] GetLessonsByTeacher(int teacherId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITeacherService/GetSubjectsByTeacher", ReplyAction="http://tempuri.org/ITeacherService/GetSubjectsByTeacherResponse")]
        VirtualClassroom.TeacherClient.TeacherServiceReference.Subject[] GetSubjectsByTeacher(int teacherId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITeacherService/AddMark", ReplyAction="http://tempuri.org/ITeacherService/AddMarkResponse")]
        void AddMark(VirtualClassroom.TeacherClient.TeacherServiceReference.Homework homework, System.Nullable<float> mark);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITeacherServiceChannel : VirtualClassroom.TeacherClient.TeacherServiceReference.ITeacherService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TeacherServiceClient : System.ServiceModel.ClientBase<VirtualClassroom.TeacherClient.TeacherServiceReference.ITeacherService>, VirtualClassroom.TeacherClient.TeacherServiceReference.ITeacherService {
        
        public TeacherServiceClient() {
        }
        
        public TeacherServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TeacherServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TeacherServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TeacherServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public VirtualClassroom.TeacherClient.TeacherServiceReference.Teacher LoginTeacher(string username, string password) {
            return base.Channel.LoginTeacher(username, password);
        }
        
        public void AddLesson(VirtualClassroom.TeacherClient.TeacherServiceReference.Lesson lesson) {
            base.Channel.AddLesson(lesson);
        }
        
        public VirtualClassroom.TeacherClient.TeacherServiceReference.Homework[] GetHomeworksByTeacher(int teacherId) {
            return base.Channel.GetHomeworksByTeacher(teacherId);
        }
        
        public VirtualClassroom.TeacherClient.TeacherServiceReference.Lesson[] GetLessonsByTeacher(int teacherId) {
            return base.Channel.GetLessonsByTeacher(teacherId);
        }
        
        public VirtualClassroom.TeacherClient.TeacherServiceReference.Subject[] GetSubjectsByTeacher(int teacherId) {
            return base.Channel.GetSubjectsByTeacher(teacherId);
        }
        
        public void AddMark(VirtualClassroom.TeacherClient.TeacherServiceReference.Homework homework, System.Nullable<float> mark) {
            base.Channel.AddMark(homework, mark);
        }
    }
}
