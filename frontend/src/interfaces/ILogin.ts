export interface ILogin
{
    username: string
    password: string
}
export interface ILoginResult
{
    success: boolean
    role: string
    token: string

}