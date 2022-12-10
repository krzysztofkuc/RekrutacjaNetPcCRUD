import { ContactCategoryModel } from "./contactCategoryModel";
import { ContactModel } from "./ContactModel";


export interface AddContactModel extends ContactModel{

  Categories: ContactCategoryModel[]
}
