import { ContactCategoryModel } from "./contactCategoryModel"

export interface ContactModel {
  Id: number
  Name: string
  Surname: string
  Email: string
  Password: string
  CategoryId: number
  Category: ContactCategoryModel
  PhoneNo: string
  DateOfBirth: Date
}
