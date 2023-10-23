import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import type { PhoneRecord } from '../Types/Types';

export const PhoneBookApi = createApi({
    reducerPath: 'phoneBookApi',
    baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:44380/api/phonebookcontroller' }),
    endpoints: (builder) => ({
    getPhoneBook: builder.query<PhoneRecord[],void>({
      query: () => '/getallrecords',
    }),
  }),
});

export const {useGetPhoneBookQuery} = PhoneBookApi;