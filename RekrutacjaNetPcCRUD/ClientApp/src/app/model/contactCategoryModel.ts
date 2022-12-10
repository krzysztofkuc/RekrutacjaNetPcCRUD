import { ContactModel } from "./ContactModel"

export interface ContactCategoryModel {
  Id: number
  Name: string
  Contacts: ContactModel[]
}
