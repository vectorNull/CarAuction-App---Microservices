import './globals.css'

export const metadata = {
  title: 'Car Auction',
  description: 'A NextJS/ASP.Net Microservices Application',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <body>{children}</body>
    </html>
  )
}
