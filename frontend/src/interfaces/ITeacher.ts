export interface ITeacher 
{
    id : string;
    name : string;
    birthday : string;
    phoneNumber : string;
    email : string;
    department : IDept;
}
export interface ITeacherRequest
{
    name : string;
    birthDay : string;
    phoneNumber : string;
    email : string;
    department : string;
}
export interface IDept{
    name : string;
}