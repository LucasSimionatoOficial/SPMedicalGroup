export const parseJwt = () => {
    let base64 = localStorage.getItem('jwt_key').split('.')[1]
    let a = JSON.parse(window.atob(base64))
    console.log(a)
    return a
}
export const usuarioAutenticado = () => localStorage.getItem('jwt_key') !== null

export const usuarioExpirado = () => new Date(parseJwt().exp * 1000)