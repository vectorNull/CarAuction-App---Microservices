'use client'

import { useParamsStore } from '@/hooks/useParamsStore'
import { useRouter, usePathname } from 'next/navigation';
import React from 'react'
import { GiCarKey } from 'react-icons/gi'

export default function Logo() {
    const reset = useParamsStore(state => state.reset);
    const router = useRouter();
    const pathname = usePathname();
    
    function doReset() {
        if(pathname !== '/') router.push('/'); 
        reset(); 
    }

    return (
        <div>
            <div onClick={doReset} 
                className='flex item-center gap-2 text-3xl font-semibold text-red-500 cursor-pointer'>
                <GiCarKey />
                <div>Car Auction</div>
            </div>
        </div>
    )
}
