export class MatTableConfigs{
columnHeader : columnHeader[]
editable? :EditableColumn= new EditableColumn();


}
export class  columnHeader{
value:string;
text:string;
search? : boolean=false;
sort? :boolean =false;
}
export class EditableColumn{
  select? :boolean=false;
  edit? :boolean=false;
  delete? :boolean=false;
}
