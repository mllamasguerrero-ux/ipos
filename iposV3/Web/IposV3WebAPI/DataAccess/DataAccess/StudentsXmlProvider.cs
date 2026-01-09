using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Models;

namespace DataAccess {
    public class StudentsXmlProvider : IDataProvider<Student> {
        private readonly XDocument doc;
        private readonly string xmlFilePath;

        public StudentsXmlProvider(string xmlFilePath) {
            this.xmlFilePath = xmlFilePath;
            doc = XDocument.Load(xmlFilePath);
        }

        public Student? GetById(int id) {
            return GetElementById(id)?.FromXElement<Student>();
        }

        public void Change(Student newEntity) {
            var entityById = GetElementById(newEntity.Id);

            entityById?.SetAttributeValue("FirstName",newEntity.FirstName ?? "");
            entityById?.SetAttributeValue("LastName",newEntity.LastName ?? "");
            entityById?.SetAttributeValue("Age", newEntity.Age.ToString());
            entityById?.SetAttributeValue("EmailAddress", newEntity.EmailAddress ?? "");
        }

        public void Add(Student entity) {
            var element = entity.ToXElement<Student>();
            doc.Root?.Add(element);
        }

        public void Remove(int id) {
            var entityById = GetElementById(id);
            entityById?.Remove();
        }

        public IEnumerable<Student?> GetAll() {
            return doc.Descendants("Student").Select(element => element.FromXElement<Student>());
        }

        public void SubmitChanges() {
            doc.Save(xmlFilePath);
        }

        private XElement? GetElementById(int id) {
            var result = doc.Descendants("Student")
                .SingleOrDefault(element =>((int?)element.Attribute("Id") ?? 0) == id);
            return result;
        }
    }
}