import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import type { PhoneRecord } from '../Types/Types';

export const PhoneBookApi = createApi({
    reducerPath: 'phoneBookApi',
    baseQuery: fetchBaseQuery({ baseUrl: 'http://localhost:3000/api/phonebookcontroller' }),
    // baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:44380/api/phonebookcontroller' }),
    tagTypes: ['PhoneBook'],
    endpoints: (builder) => ({
    GetPhoneBook: builder.query<PhoneRecord[],void>({
      query: () => '/getallrecords',
      providesTags: ['PhoneBook'],
    }),
    AddPhoneBookRecord: builder.mutation<PhoneRecord,PhoneRecord>({
      query: (data) =>{
        console.log(data);
      return  ({
          url: `/addrecord?name=${data.name}&phone=${data.phone}`,
          method: 'POST',
        })
      } ,
      invalidatesTags: ['PhoneBook'],
    }),
    GetPhoneBookById: builder.query<PhoneRecord,string>({
      query: (data) => ({
        url: `/getrecordbyid/${data}`,
      }),
      providesTags: ['PhoneBook'],
    }),
    UpdatePhoneBook: builder.mutation<PhoneRecord,PhoneRecord>({
      query: (data) => ({
        url: `/updaterecord?id=${data.id}&name=${data.name}&phone=${data.phone}`,
        method: 'PUT',
      }),
      invalidatesTags: ['PhoneBook'],
    }),
    DeletePhoneBook: builder.mutation<PhoneRecord,string>({
      query: (data) => ({
        url: `/deleterecord?id=${data}`,
        method: 'DELETE',
      }),
      invalidatesTags: ['PhoneBook'],
    })
  }),
});

export const 
{
  useGetPhoneBookQuery,
  useGetPhoneBookByIdQuery,
  useAddPhoneBookRecordMutation,
  useUpdatePhoneBookMutation,
  useDeletePhoneBookMutation
} = PhoneBookApi;