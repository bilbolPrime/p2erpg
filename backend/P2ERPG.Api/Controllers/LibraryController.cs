using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BilbolStack.Boonamai.P2ERPG.Api.Controllers
{
    [ApiController]
    [Route("library")]
    public class LibraryController : ControllerBase
    {
        private readonly ILogger<LibraryController> _logger;

        public LibraryController(ILogger<LibraryController> logger)
        {
            _logger = logger;
        }

        [HttpGet("armor")]
        public IActionResult GetArmorTypes()
        {
            var armorTypes = Enum.GetValues(typeof(ArmorType))
                .Cast<ArmorType>()
                .Select(a => new 
                {
                    Id = (int)a,
                    Name = a.ToString()
                })
                .ToList();
            
            return Ok(armorTypes);
        }

        [HttpGet("shield")]
        public IActionResult GetShieldTypes()
        {
            var shieldTypes = Enum.GetValues(typeof(ShieldType))
                .Cast<ShieldType>()
                .Select(s => new 
                {
                    Id = (int)s,
                    Name = s.ToString()
                })
                .ToList();
            
            return Ok(shieldTypes);
        }
        
        [HttpGet("weapon")]
        public IActionResult GetWeaponTypes()
        {
            var weaponTypes = Enum.GetValues(typeof(WeaponType))
                .Cast<WeaponType>()
                .Select(w => new 
                {
                    Id = (int)w,
                    Name = w.ToString()
                })
                .ToList();
            
            return Ok(weaponTypes);
        }
        
        [HttpGet("character")]
        public IActionResult GetCharacterTypes()
        {
            var characterTypes = Enum.GetValues(typeof(CharacterType))
                .Cast<CharacterType>()
                .Select(c => new 
                {
                    Id = (int)c,
                    Name = c.ToString()
                })
                .ToList();
            
            return Ok(characterTypes);
        }
        
        [HttpGet("pvetarget")]
        public IActionResult GetPvETargets()
        {
            var pveTargets = Enum.GetValues(typeof(PvETarget))
                .Cast<PvETarget>()
                .Select(t => new 
                {
                    Id = (int)t,
                    Name = t.ToString()
                })
                .ToList();
            
            return Ok(pveTargets);
        }
    }
} 