import { ContactCategoryModel } from "./contactCategoryModel"

export interface ContactSubategoryModel{
  Id: number
  Name: string
  CategoryId: number
  Category: ContactCategoryModel
}
