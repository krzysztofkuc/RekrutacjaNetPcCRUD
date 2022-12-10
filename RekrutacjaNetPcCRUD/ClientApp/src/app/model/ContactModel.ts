import { ContactCategoryModel } from "./contactCategoryModel"

export interface ContactModel {
  Id: number
  Name: string
  Surname: string
  Email: string
  Password: string
  Category: string
  PhoneNo: string
  DateOfBirth: Date
}
