import axios, { AxiosResponse } from 'axios';

const axiosClient = axios.create({
  baseURL: `http://localhost:27727/api`,
  headers: {
    'Content-type': 'application/json',
  },
  withCredentials: true,
});
axiosClient.interceptors.response.use(
  (response: AxiosResponse) => response,
  (error) => {
    const { response } = error;
    const errorMessage = response?.data?.error_message ?? 'Error';

    console.log(errorMessage);

    return Promise.reject(error);
  },
);

export default axiosClient;