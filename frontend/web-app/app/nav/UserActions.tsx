'use client'

import { Dropdown } from 'flowbite-react'
import React from 'react'
import { User } from 'next-auth'
import { HiCog, HiUser } from 'react-icons/hi2'
import Link from 'next/link'
import { AiFillCar, AiFillTrophy, AiOutlineLogout } from 'react-icons/ai'
import { signOut } from 'next-auth/react'
import { usePathname, useRouter } from 'next/navigation'
import { useParamsStore } from '@/hooks/useParamsStore'

type Props = {
	user: User
}

export default function UserActions({ user }: Props) {
	const router = useRouter();
	const pathname = usePathname();
	const setParams = useParamsStore(state => state.setParams);
	console.log("user: ", user);

	function setWinner() {
		setParams({ winner: user.username, seller: undefined })
		console.log('inside setWinner: ', user.username);
		if (pathname !== '/') router.push('/')
	}

	function setSeller() {
		setParams({ seller: user.username, winner: undefined })
		console.log('inside setSeller: ', user.username);
		if (pathname !== '/') router.push('/')
	}

	return (
		<Dropdown
			inline
			label={`Welcome ${user.name}`}
		>
			<Dropdown.Item icon={HiUser} onClick={setSeller}>
				My Auctions
			</Dropdown.Item>
			<Dropdown.Item icon={AiFillTrophy} onClick={setWinner}>
				Auctions Won
			</Dropdown.Item>
			<Dropdown.Item icon={AiFillCar}>
				<Link href='/auctions/create'>
					Sell My Car
				</Link>
			</Dropdown.Item>
			<Dropdown.Item icon={HiCog}>
				<Link href='/session'>
					Session (dev only)
				</Link>
			</Dropdown.Item>
			<Dropdown.Divider />
			<Dropdown.Item icon={AiOutlineLogout} onClick={() => signOut({ callbackUrl: '/' })}>
				Sign Out
			</Dropdown.Item>
		</Dropdown>
	)
}
