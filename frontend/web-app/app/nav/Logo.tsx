'use client'

import { useParamsStore } from '@/hooks/useParamsStore'
import React from 'react'
import { GiCarKey } from 'react-icons/gi'

export default function Logo() {
    const reset = useParamsStore(state => state.reset);

    return (
        <div>
            <div onClick={reset} 
                className='flex item-center gap-2 text-3xl font-semibold text-red-500 cursor-pointer'>
                <GiCarKey />
                <div>Car Auction</div>
            </div>
        </div>
    )
}
