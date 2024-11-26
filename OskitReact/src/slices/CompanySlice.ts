import { createSlice } from '@reduxjs/toolkit'
import IReducerPayloadAction from '../types/IReducerPayloadAction'
import ICompany from '../types/ICompany'

const CompanySlice = createSlice({
	name: "companies",
	initialState: {
		current: {

		} as ICompany,
		companies: [] as ICompany[]
	},
	reducers: {
		AddCompany: (state, action: IReducerPayloadAction<ICompany>) => {
			state.companies.push(action.payload)
		},
		SelectCompany: (state, action: IReducerPayloadAction<ICompany>) => {
			state.current = action.payload
		}
	},
	selectors: {
		GetCurrentCompany: state => state.current,
		GetCompanies: state => state.companies
	}
})

export const { SelectCompany, AddCompany } = CompanySlice.actions
export const { GetCompanies, GetCurrentCompany } = CompanySlice.selectors
export default CompanySlice.reducer