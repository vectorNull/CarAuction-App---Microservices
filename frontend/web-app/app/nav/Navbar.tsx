import React from 'react'
import { GiCarKey } from 'react-icons/gi'

export default function Navbar() {
	return (
		<header className='
      		sticky top-0 z-50 flex justify-between bg-white p-5 items-center text-gray-800 shadow-md'>
			<div className='flex item-center gap-2 text-3xl font-semibold text-red-500'>
				<GiCarKey />
				<div>Car Auction</div>
			</div>
			<div>Search</div>
			<div>Login</div>
		</header>
	)
}
